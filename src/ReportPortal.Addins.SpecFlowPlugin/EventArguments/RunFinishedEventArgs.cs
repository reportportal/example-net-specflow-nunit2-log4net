﻿using System;
using ReportPortal.Client;
using ReportPortal.Client.Requests;

namespace ReportPortal.Addins.SpecFlowPlugin.EventArguments
{
    public class RunFinishedEventArgs: EventArgs
    {
        private readonly Service _service;
        private readonly FinishLaunchRequest _request;
        private readonly string _message;
        public RunFinishedEventArgs(Service service, FinishLaunchRequest request)
        {
            _service = service;
            _request = request;
        }

        public RunFinishedEventArgs(Service service, FinishLaunchRequest request, string message)
            :this(service, request)
        {
            _message = message;
        }

        public Service Service
        {
            get { return _service; }
        }

        public FinishLaunchRequest Launch
        {
            get { return _request; }
        }

        public string Id
        {
            get { return _message; }
        }

        public bool Canceled { get; set; }
    }
}
