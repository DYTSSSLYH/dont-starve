using System;
using System.Collections.Generic;

public class EventProcessor
{
    public class EventHandler
    {
        public string eventName;
        public Action<object[]> fn;
        public EventProcessor processor;

        public EventHandler(string eventName, Action<object[]> fn, EventProcessor processor)
        {
            this.eventName = eventName;
            this.fn = fn;
            this.processor = processor;
        }
    }
    private readonly Dictionary<string, List<EventHandler>> events =
        new Dictionary<string, List<EventHandler>>();


    public EventHandler AddEventHandler(string eventName, Action<object[]> fn)
    {
        EventHandler handler = new EventHandler(eventName, fn, this);
        
        if (!events.ContainsKey(eventName)) events.Add(eventName, new List<EventHandler>());
        
        events[eventName].Add(handler);

        return handler;
    }
}