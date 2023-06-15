using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace PlayFab
{
    public class PlayFabIntegration : MonoBehaviour
    {
        public static PlayFabIntegration Instance;

        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }

        private LoginResult _loginResult;

        private void Awake()
        {
           
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #region register
        public void Register()
        {
            var request = new RegisterPlayFabUserRequest
            {
                Email = "Woutdevis@live.be",
                Username = "PlayerTwo",
                Password = "abc123",
                DisplayName = "PlayerTwo"
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);

        }

        private void OnRegisterFailure(PlayFabError error)
        {
            Debug.Log("registraton failed: " + error.ErrorMessage);
        }

        private void OnRegisterSuccess(RegisterPlayFabUserResult result)
        {
            Debug.Log("User registration succeeded for " + result.Username);
        }
        #endregion

        #region login


        public void Login()
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = Email.Trim(),
                Password = Password.Trim(),
            };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnAPICallFailure);
        }

        private void OnLoginSuccess(LoginResult Result)
        {
            _loginResult = Result;
            Debug.Log("Login succesfull");
            GetUserInventory();
        }
        #endregion

        #region User inventory

        private void GetUserInventory()
        {
            GetUserInventoryRequest request = new GetUserInventoryRequest { AuthenticationContext = _loginResult.AuthenticationContext };
            PlayFabClientAPI.GetUserInventory(request, OnGetUSerInventorySuccess, OnAPICallFailure);
        }

        private void OnGetUSerInventorySuccess(GetUserInventoryResult result)
        {
            Debug.Log("inventory: " + result.VirtualCurrency["GO"] + "gold");
            Debug.Log("inventory: items ");
            foreach (ItemInstance ii in result.Inventory)
            {
                Debug.Log(ii.DisplayName);
            }
        }


        #endregion

        #region IncreaseFunds
        public void IncreasePlayerFunds()
        {
            AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest
            {
                AuthenticationContext = _loginResult.AuthenticationContext,
                Amount = 100,
                VirtualCurrency = "GO",
            };
            PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddUserCurrencySuccess, OnAPICallFailure);
        }

        private void OnAddUserCurrencySuccess(ModifyUserVirtualCurrencyResult result)
        {
            Debug.Log("Add virtual currency succeeded: " + result.Balance);
        }
        #endregion

        #region PurchaseExcalibur

        public void PurchaseExcalibur()
        {
            PurchaseItemRequest request = new PurchaseItemRequest
            {
                AuthenticationContext = _loginResult.AuthenticationContext,
                CatalogVersion = "MemoryGame",
                ItemId = "1",
                Price = 100,
                VirtualCurrency = "GO"
            };
            PlayFabClientAPI.PurchaseItem(request, OnBuySuccess, OnAPICallFailure);
        }

        private void OnBuySuccess(PurchaseItemResult obj)
        {
            Debug.Log("Purchase succeeded!");
            GetUserInventory();
        }
        #endregion

        private void OnAPICallFailure(PlayFabError error)
        {
            Debug.Log("The following error occured: " + error.ErrorMessage);
        }
    }
}

