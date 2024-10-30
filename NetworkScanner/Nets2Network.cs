﻿using RetailPlan.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPlan.POS.NETS
{
    public class Nets2Network
    {
        string sSendData, sReceiveData, sBank = "DBS", msTransactionStatus = "", msResponse = "";
        private bool mbTransactionSuccess = false;
        //private bool mbNetworkConnection = false;
        //System.Timers.Timer tmrSync;
        //TcpClient client;

        Dictionary<string, string> responseData = new Dictionary<string, string>()
        {
            {"EDCMode", ""},
            {"ApprovalCode", ""},
            {"TransactionNo", ""},
            {"TerminalId", ""},
            {"MerchantId", ""},
            {"CardIssuerName", ""},
            {"CardHolderName", ""},
            {"CardNo", ""},
            {"CardExpiry", ""},
            {"BatchNo", ""},
            {"ReferenceNo", ""},
            {"RRNNo", ""},
            {"EntryType", ""},
            {"InvoiceNo", ""},
            {"AppId", ""},
            {"TVRNo", ""},
            {"ResponseText", ""}
        };

        public Dictionary<string, string> EDCResponseData
        {
            get { return responseData; }
            set { responseData = value; }
        }

        private void NetsNetword()
        {
            sReceiveData = "";
            sBank = NetsSettings.Bank;
            
        }

        public bool TransactionSuccess
        {
            get { return mbTransactionSuccess; }
        }

        public string TransactionStatus
        {
            get { return msTransactionStatus; }
        }


        public void ProcessNetsNetwork(string sPayMode, decimal dAmount)
        {
            try
            {
                string sECRNumber = DateTime.Now.ToString("yyMMddHHmmss");
                string sIPAddress = NetsSettings.IPAddress;
                int nPortNo = 3000;
                //nPortNo = Convert.ToInt32(NetsSettings.PortNo);
                FillSendData(sPayMode, dAmount, sECRNumber);
                bool bTimeOut = false;
                ConnectNetworkTerminal(sIPAddress, nPortNo, ref bTimeOut);
                //send data again if the timeout occurs.
                //if (bTimeOut || sReceiveData == null)
                //{
                //    Application.DoEvents();
                //    Thread.Sleep(10000);
                //    ConnectNetworkTerminal(sIPAddress, nPortNo, ref bTimeOut);
                //}
                if (!bTimeOut)
                {
                    //do nothing
                }
                else
                {
                    Application.DoEvents();
                    //resend it after 40 seconds due to network disturbance
                    Thread.Sleep(60 * 1000);
                    ConnectNetworkTerminal(sIPAddress, nPortNo, ref bTimeOut);
                }
                LocalSettings.WriteLog("Receive Data - " + sReceiveData);
                if (sReceiveData.Length > 40)
                {
                    msResponse =  FormatHelper.GetStringFromHex(sReceiveData.Substring(32, 4));

                    if (sPayMode == "NETSQR2PRIME" && msResponse == "00")
                    {
                        FillSendData(sPayMode + "2", dAmount, sECRNumber);
                        ConnectNetworkTerminal(sIPAddress, nPortNo, ref bTimeOut);
                        msResponse = FormatHelper.GetStringFromHex(sReceiveData.Substring(32, 4));

                    }

                    if (msResponse == "00")
                    {
                        mbTransactionSuccess = true;
                        msTransactionStatus = "SUCCESS";
                        FillResponseData(sReceiveData);
                    }
                    else
                    {
                        msTransactionStatus = GetNETSErrorMsg(msResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                LocalSettings.WriteLog(ex.Message.ToString());
            }

        }

        private void FillResponseData(string sReceiveData)
        {
            try
            {
                string sTemp = "";
                if (sReceiveData.IndexOf("443115") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("443115") + 6, 30));
                    responseData["MerchantId"] = sTemp;
                }
                if (sReceiveData.IndexOf("313608") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("313608") + 6, 16));
                    responseData["TerminalId"] = sTemp;
                }
                if (sReceiveData.IndexOf("303106") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("303106") + 6, 12));
                    responseData["ApprovalCode"] = sTemp;
                }
                if (sReceiveData.IndexOf("333016") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("333016") + 6, 32));
                    responseData["CardNo"] = sTemp;
                }
                if (sReceiveData.IndexOf("443210") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("443210") + 6, 20));
                    responseData["CardIssuerName"] = sTemp;
                }
                if (sReceiveData.IndexOf("363506") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("363506") + 6, 12));
                    responseData["TransactionNo"] = sTemp;
                }
                if (sReceiveData.IndexOf("394806") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("394806") + 6, 12));
                    responseData["InvoiceNo"] = sTemp;
                }
                if (sReceiveData.IndexOf("443312") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("443312") + 6, 24));
                    responseData["RRNNo"] = sTemp;
                }
                if (sReceiveData.IndexOf("434E02") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("434E02") + 6, 4));
                    if (sTemp == "10")
                    {
                        sTemp = "Chip Card";
                    }
                    else if (sTemp == "20")
                    {
                        sTemp = "Contactless";
                    }
                    else sTemp = "Swipe";
                    responseData["EntryType"] = sTemp;
                }
                //if (sReceiveData.IndexOf("333104") != -1)
                //{
                //    responseData["CardExpiry"] = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("33310004") + 8, 8));
                //}
                ////Batch No.
                //if (sReceiveData.IndexOf("353006") != -1)
                //{
                //    responseData["BatchNo"] = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("35300006") + 8, 12));
                //}
                //if (sReceiveData.IndexOf("394116") != -1)
                //{
                //    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("39410016") + 8, 32));
                //    responseData["AppId"] = sTemp;
                //}
                //if (sReceiveData.IndexOf("394510") != -1)
                //{
                //    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("39450010") + 8, 20));
                //    responseData["TVRNo"] = sTemp;
                //}
                if (sReceiveData.IndexOf("303240") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("30320040") + 8, 80));
                    responseData["ResponseText"] = sTemp;
                }
                if (sReceiveData.IndexOf("4C3720") != -1)
                {
                    sTemp = FormatHelper.GetStringFromHex(sReceiveData.Substring(sReceiveData.IndexOf("4C3720") + 6, 40));
                    responseData["CardHolderName"] = sTemp;
                }

            }
            catch (Exception ex)
            {
                LocalSettings.WriteLog(ex.Message.ToString());
            }
        }


        private void FillSendData(string sType, decimal dAmount, string sECRNumber)
        {
            string sLRCData = "";
            sSendData = "";
            switch (sType)
            {
                case "NETS":
                    sSendData += "00 84 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "33 30 " + "30 31 30 1C ";                             //function code (30)
                    sSendData += "54 32 00 02 " + "30 31" + " 1C ";                     //Type - 01.
                    sSendData += "34 33 00 01 30 1C ";                                  //Loyalty redemption
                    sSendData += "34 30 00 12 " + FormatHelper.GetAmountInHex(dAmount, 12) + "1C ";  //Amount
                    sSendData += "34 32 00 12 30 30 30 30 30 30 30 30 30 30 30 30 1C "; //Cash Back
                    sSendData += "48 44 00 13 " + FormatHelper.GetStringInHex(sECRNumber, 13) + "1C "; //ECR in Detail
                    break;
                case "NETSQR":
                    sSendData += "00 66 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "33 30 " + "30 31 30 1C ";                             //function code (30)
                    sSendData += "54 32 00 02 " + "30 34" + " 1C ";                     //Type - 04.
                    sSendData += "34 33 00 01 30 1C ";                                  //Loyalty redemption
                    sSendData += "34 30 00 12 " + FormatHelper.GetAmountInHex(dAmount, 12) + "1C ";  //Amount
                    sSendData += "34 32 00 12 30 30 30 30 30 30 30 30 30 30 30 30 1C "; //Cash Back
                    break;
                case "NETSQR2PRIME":
                    sSendData += "00 36 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "51 31 " + "30 31 30 1C ";                             //function code (Q1)
                    sSendData += "34 30 00 12 " + FormatHelper.GetAmountInHex(dAmount, 12) + "1C ";  //Amount
                    break;
                case "NETSQR2PRIME2":
                    sSendData += "01 47 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "51 32 " + "30 31 30 1C ";                             //function code (Q1)
                    sSendData += "34 30 00 12 " + FormatHelper.GetAmountInHex(dAmount, 12) + "1C ";  //Amount
                    break;
                case "NETSFP":
                    sSendData += "00 51 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "32 34 " + "30 31 30 1C ";                             //function code (24)
                    sSendData += "34 30 00 12 " + FormatHelper.GetAmountInHex(dAmount, 12) + "1C ";  //Amount
                    sSendData += "48 44 00 10 " + FormatHelper.GetStringInHex(sECRNumber.Substring(0, 10), 10) + "1C "; //ECR in Detail
                    break;
                case "NETSCC":
                    sSendData += "00 36 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "35 31 " + "30 31 30 1C ";                             //function code (51)
                    sSendData += "34 30 00 12 " + FormatHelper.GetAmountInHex(dAmount, 12) + "1C "; //Amount
                    break;
                case "CREDITCARD":
                    sSendData += "00 47 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "49 30 " + "30 31 30 1C ";                             //function code (I0)
                    sSendData += "34 30 00 12 " + FormatHelper.GetAmountInHex(dAmount, 12) + "1C ";  //Amount
                    sSendData += "39 47 00 06 " + FormatHelper.GetStringInHex(sBank, 6) + "1C ";     //Bank
                    break;
                case "NETS_LOGON":
                    sSendData += "00 19 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "38 30 " + "30 31 30 1C ";                             //function code (80)
                    break;
                case "NETS_SETTLEMENT":
                    sSendData += "00 19 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "38 31 " + "30 31 30 1C ";                             //function code (81)
                    break;
                case "NETS_TERMINALMAINTENANCE":
                    sSendData += "00 19 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "38 34 " + "30 31 30 1C ";                             //function code (84)
                    break;
                case "NETS_CREDITCARDSETTLEMENT":
                    sSendData += "00 30 ";                                              //length
                    sSendData += FormatHelper.GetStringInHex(sECRNumber, 12);                        //ECR
                    sSendData += "49 35 " + "30 31 30 1C ";                             //function code (81)
                    sSendData += "39 47 00 06 " + FormatHelper.GetStringInHex(sBank, 6) + "1C ";     //Bank
                    break;
            }
            sSendData = sSendData.Replace(" ", "");
            if (sSendData.Length <= 4) return;
            sLRCData = FormatHelper.GetLRC(sSendData.Substring(4, sSendData.Length - 4));
            sSendData += sLRCData;
        }

        private void PollByTimers()
        {
            //tmrSync = new System.Timers.Timer();
            //tmrSync.Interval = 1000;
            //tmrSync.Elapsed += tmrSync_Elapsed;
            //tmrSync.Enabled = true;
            //tmrSync.Start();
        }

        //void tmrSync_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    try
        //    {
        //        if (client.Client.Poll(0, SelectMode.SelectRead))
        //        {
        //            byte[] buff = new byte[1];
        //            if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
        //            {
        //                // Client disconnected
        //                mbNetworkConnection = false;
        //            }
        //            //else
        //            //{
        //            //    mbNetworkConnection = true;
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LocalSettings.WriteLog(ex.Message.ToString());
        //    }
        //}


        public void ConnectNetworkTerminal(String sIPAddress, int nPortNo, ref bool bTimeOut)
        {
            TcpClient client = new TcpClient();
            NetworkStream stream = null;
            try
            {
                bTimeOut = false;
                // Create a TcpClient.
                client.SendTimeout = 120 * 1000;
                client.ReceiveTimeout = 60 * 1000;

                client.Connect(sIPAddress, nPortNo);
                // Translate the passed message into ASCII and store it as a Byte array.
                //Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                byte[] bytes = FormatHelper.HexStringToByteArray(sSendData);

                stream = client.GetStream();

                stream.ReadTimeout = 40 * 1000;

                // Send the message to the connected TcpServer. 
                stream.Write(bytes, 0, bytes.Length);
                LocalSettings.WriteLog("Send Data - " + sSendData);

                //mbNetworkConnection = true;
                //PollByTimers();

                //stream.ReadTimeout = 2000;
                //client.ReceiveTimeout = 2000;

                // Buffer to store the response bytes.
                byte[] data = new byte[8000];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytesReceive = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytesReceive);
                sReceiveData = FormatHelper.ConvertStringToHex(responseData);

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (IOException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                bTimeOut = true;
                LocalSettings.WriteLog("IO exception - timeout " + e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                LocalSettings.WriteLog("Socket error " + e);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (client != null) client.Close();
                //tmrSync.Stop();
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }

        private string GetNETSErrorMsg(string sResponeCode)
        {
            string sErrorMsg = "";
            switch (sResponeCode)
            {
                case "01":
                    sErrorMsg = "REFER TO NETS";
                    break;
                case "02":
                    sErrorMsg = "REFER TO BANK";
                    break;
                case "03":
                    sErrorMsg = "INVALID TERMINAL";
                    break;
                case "12":
                    sErrorMsg = "INVALID TRANS";
                    break;
                case "13":
                    sErrorMsg = "INVALID AMOUNT";
                    break;
                case "14":
                    sErrorMsg = "INVALID CARD";
                    break;
                case "19":
                    sErrorMsg = "RE-ENTER TRANSACTION";
                    break;
                case "25":
                    sErrorMsg = "NO RECORD ON FILE";
                    break;
                case "30":
                    sErrorMsg = "REFER TO NETS";
                    break;
                case "31":
                case "42":
                case "43":
                    sErrorMsg = "INVALID CARD";
                    break;
                case "51":
                    sErrorMsg = "DECLINED";
                    break;
                case "54":
                    sErrorMsg = "EXPIRED";
                    break;
                case "55":
                    sErrorMsg = "INCORRECT PIN";
                    break;
                case "58":
                    sErrorMsg = "INVALID TRANSACTION";
                    break;
                case "61":
                    sErrorMsg = "DAILY LIMIT EXCEEDED";
                    break;
                case "62":
                    sErrorMsg = "INVALID TRANSACTION";
                    break;
                case "63":
                    sErrorMsg = "VOID IMPOSSIBLE";
                    break;
                case "64":
                    sErrorMsg = "TXN ALREADY VOID";
                    break;
                case "65":
                    sErrorMsg = "VOID IMPOSSIBLE";
                    break;
                case "75":
                    sErrorMsg = "PIN ERROR, REFER TO BANK";
                    break;
                case "76":
                case "86":
                    sErrorMsg = "DECLINED";
                    break;
                case "78":
                    sErrorMsg = "INVALID CARD";
                    break;
                case "79":
                    sErrorMsg = "SUPERVISOR PIN ERROR";
                    break;
                case "80":
                case "81":
                    sErrorMsg = "INVALID CARD";
                    break;
                case "82":
                    sErrorMsg = "PIN ERROR, REFER TO NETS";
                    break;
                case "85":
                    sErrorMsg = "INVALID CARD";
                    break;
                case "87":
                    sErrorMsg = "DAILY LIMIT EXCEEDED";
                    break;
                case "88":
                    sErrorMsg = "NO MERCH RET";
                    break;
                case "89":
                    sErrorMsg = "INVALID TERMINAL";
                    break;
                case "91":
                    sErrorMsg = "NO REPLY FROM BANK";
                    break;
                case "98":
                    sErrorMsg = "MAC ERROR";
                    break;
                case "IM":
                    sErrorMsg = "UNAUTHORISED RESPONSE";
                    break;
                case "IR":
                    sErrorMsg = "INVALID HOST MESSAGE";
                    break;
                case "IT":
                    sErrorMsg = "INVALID TERMINAL";
                    break;
                case "IA":
                    sErrorMsg = "INVALID HOST AMOUNT";
                    break;
                case "IC":
                    sErrorMsg = "INVALID CARD";
                    break;
                case "IL":
                    sErrorMsg = "INVALID DATA LENGTH";
                    break;
                case "HS":
                    sErrorMsg = "CONNECT PROBLEM TO HOST";
                    break;
                case "TO":
                    sErrorMsg = "TIMEOUT-PLEASE TRY AGAIN";
                    break;
                case "US":
                    sErrorMsg = "CANCELLED BY USER";
                    break;
                case "BF":
                    sErrorMsg = "TRANSACTION BATCH FULL";
                    break;
                case "SC":
                    sErrorMsg = "CASHCARD TRANSACTION UNSUCCESSFUL";
                    break;
                case "N0":
                    sErrorMsg = "DIFFERENT ISSUERS FOR A NETS SALE OR REVALUTION";
                    break;
                case "N1":
                    sErrorMsg = "CASHCARD BLACKLIST";
                    break;
                case "N2":
                    sErrorMsg = "BATCH ALREADY UPLOADED";
                    break;
                case "N3":
                    sErrorMsg = "RESEND BATCH";
                    break;
                case "N4":
                    sErrorMsg = "CASHCARD NOT FOUND";
                    break;
                case "N5":
                    sErrorMsg = "EXPIRED";
                    break;
                case "N6":
                    sErrorMsg = "REFUNDED CASHCARD";
                    break;
                case "N7":
                    sErrorMsg = "CERTIFICATE ERROR";
                    break;
                case "N8":
                    sErrorMsg = "INSUFFICIENT FUNDS/BALANCE";
                    break;
                case "IS":
                    sErrorMsg = "INVALID STAN*";
                    break;
                case "RN":
                    sErrorMsg = "RECORD NOT FOUND";
                    break;
                case "RE":
                    sErrorMsg = "READER NOT READY";
                    break;
                case "T1":
                    sErrorMsg = "INVALID TOP-UP CARD";
                    break;
                case "T2":
                    sErrorMsg = "TERMINAL TOP-UP LIMIT EXCEEDED";
                    break;
                case "T3":
                    sErrorMsg = "RETAILER LIMIT EXCEEDED";
                    break;
                case "LR":
                    sErrorMsg = "MANUAL LOGON REQUIRED**";
                    break;
                case "DK":
                    sErrorMsg = "BLOCKLIST DOWNLOAD REQUIRED";
                    break;
                case "DS":
                    sErrorMsg = "CASHCARD SETTLEMENT REQUIRED";
                    break;
                case "BP":
                    sErrorMsg = "CARD BLOCKED";
                    break;
                case "BA":
                    sErrorMsg = "TRANSACTION BLOCKED, to prevent Autoload";
                    break;
                case "GB":
                    sErrorMsg = "Golden Bullet Card";
                    break;
                default:
                    sErrorMsg = "NETS Transaction Error";
                    break;
            }
            return (sErrorMsg);
        }


    }
}
