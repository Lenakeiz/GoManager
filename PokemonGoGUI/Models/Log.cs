﻿using Newtonsoft.Json;
using PokemonGo.RocketAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGoGUI.GoManager.Models
{
    public enum LoggerTypes { Debug, Info, Warning, Exception, PokemonEscape, PokemonFlee, LocationUpdate, Transfer, Evolve, Incubate, Recycle, ProxyIssue, Success };

    public class Log
    {
        public LoggerTypes LoggerType { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
        public string ExceptionMessage { get; private set; }

        /*
        public string ExceptionMessage
        {
            get
            {
                if(Exception == null)
                {
                    return String.Empty;

                }

                return Exception.Message;
            }
        }*/

        public Log(LoggerTypes type, string message, Exception exception = null)
        {
            this.LoggerType = type;
            this.Message = message;
            this.Date = DateTime.Now;

            if (exception != null)
            {
                this.StackTrace = exception.StackTrace;
                this.ExceptionMessage = exception.Message;
            }
        }

        public Color GetLogColor()
        {
            switch (this.LoggerType)
            {
                case LoggerTypes.Exception:
                    return Color.Red;
                case LoggerTypes.Success:
                    return Color.Green;
                case LoggerTypes.Warning:
                    return Color.Yellow;
                case LoggerTypes.ProxyIssue:
                    return Color.Yellow;
                case LoggerTypes.PokemonFlee:
                    return Color.Salmon;
                case LoggerTypes.PokemonEscape:
                    return Color.DarkGoldenrod;
                case LoggerTypes.Transfer:
                    return Color.MediumAquamarine;
                case LoggerTypes.Evolve:
                    return Color.MediumAquamarine;
                case LoggerTypes.Incubate:
                    return Color.MediumAquamarine;
                case LoggerTypes.Recycle:
                    return Color.MediumAquamarine;
                case LoggerTypes.Info:
                    return Color.Teal;
                case LoggerTypes.Debug:
                    return Color.DarkGray;
                case LoggerTypes.LocationUpdate:
                    return Color.DarkGray;
            }

            return SystemColors.WindowText;
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(ExceptionMessage))
            {
                return String.Format("Date: {0} Type: {1} Message: {2} Exception: {3}", Date, LoggerType, Message, ExceptionMessage);
            }

            return String.Format("Date: {0} Type: {1} Message: {2}", Date, LoggerType, Message);
        }
    }
}
