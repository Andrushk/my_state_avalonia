using System;
using System.Collections.Generic;

namespace MyState.Models
{
    public class ActionsHistory
    {
        private List<ActionsHistoryItem> _items = new List<ActionsHistoryItem>();

        public IReadOnlyList<ActionsHistoryItem> Items => _items;

        public void Add(UserState state)
        {
            _items.Add(new ActionsHistoryItem
            {
                UserId = state.UserId,
                UserName = state.UserName,
                State = state.State,
                StateTime = state.StateTime
            });
        }
    }

    public class ActionsHistoryItem
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public UserStates State { get; set; }

        public DateTime StateTime { get; set; }
    }
}