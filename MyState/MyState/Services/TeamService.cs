using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyState.Models;

namespace MyState.Services
{
    //TODO переделать на DI
    public static class TeamService
    {
        //TODO вынести в отдельный класс (это же получается локальный демо-репо, вот пусть и лежит в отдельном классе) и пусть инициализируется при первом обращении
        private static Guid _guidSergey = Guid.NewGuid();
        private static Guid _guidKaterina = Guid.NewGuid();
        private static Guid _guidAndrey = Guid.NewGuid();

        private static readonly List<UserState> MyTeam = new()
        {
            new()
            {
                UserId = _guidSergey, UserName = "Sergey", State = UserStates.AtWork, StateTime = DateTime.Today.AddHours(7)
            },
            new()
            {
                UserId = _guidKaterina, UserName = "Katerina", State = UserStates.AtWork, StateTime = DateTime.Today.AddHours(5)
            },
            new()
            {
                UserId = _guidAndrey, UserName = "Andrey", State = UserStates.Unknown, StateTime = DateTime.Today.AddDays(-1)
            },
        };

        private static readonly ActionsHistory History = new();

        public static event EventHandler<List<UserState>> MyTeamStateChanged;

        /// <summary>
        /// Костыль, чтобы было удобно обновлять список даже с формы с кнопками действий
        /// </summary>
        public static async void RefreshMyTeamState()
        {
            var values = await GetMyTeam();
            OnMyTeamStateChanged(values.ToList());
        }

        /// <summary>
        /// Возвращает состояния моей команды
        /// </summary>
        private static Task<IEnumerable<UserState>> GetMyTeam()
        {
            switch (PlatformService.CurrentPlatform)
            {
                case RunPlatform.Web:
                    return GetMyTeamLocal();
                default:
                    return GetMyTeamRemote();
            }
        }

        private static async Task<IEnumerable<UserState>> GetMyTeamLocal()
        {
            await Task.Delay(800);
            return MyTeam;
        }

        private static async Task<IEnumerable<UserState>> GetMyTeamRemote()
        {
            using var httpClient = new HttpClient();
            await using Stream responseStream = await httpClient.GetStreamAsync($"{PlatformService.ApiUri}/team_now_states");

            var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var responseData = await JsonSerializer.DeserializeAsync<List<UserState>>(responseStream, serializerOptions);

            await Task.Delay(500);

            return responseData ?? new List<UserState>();
        }

        /// <summary>
        ///  Добавить состояние пользователя
        /// </summary>
        public static Task AddState(UserStates newState)
        {
            switch (PlatformService.CurrentPlatform)
            {
                case RunPlatform.Web:
                    return AddStateLocal(newState);
                default:
                    return AddStateRemote(newState);
            }
        }

        private static async Task AddStateLocal(UserStates newState)
        {
            await Task.Delay(8); //800
            var myState = MyTeam.FirstOrDefault(x => x.UserId == _guidAndrey);
            if (myState != null)
            {
                myState.State = newState;
                myState.StateTime = DateTime.Now;

                History.Add(myState);
            }

            RefreshMyTeamState();
        }

        private static Task AddStateRemote(UserStates newState)
        {
            // Не дописал, пока остается локальная версия
            throw new NotImplementedException();

            //using StringContent jsonContent = new(
            //    JsonSerializer.Serialize(new
            //    {
            //        UserId = 77,
            //        title = newState,
            //    }),
            //    Encoding.UTF8,
            //    "application/json");

            //using var httpClient = new HttpClient();
            //using HttpResponseMessage response = await httpClient.PostAsync(
            //    "todos",
            //    jsonContent);


        }

        /// <summary>
        /// Возвращает мою историю изменения статусов
        /// </summary>
        public static IEnumerable<ActionsHistoryItem> GetMyHistory()
        {
            return History.Items.Where(x => x.UserId == _guidAndrey);
        }

        private static void OnMyTeamStateChanged(List<UserState> e)
        {
            MyTeamStateChanged?.Invoke(null, e);
        }
    }
}