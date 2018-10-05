using BankAccountAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankAccountClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            accounts = new Dictionary<long, Account>();
            BtnOpenSA.Click += OnOpenSavingAccount;
            BtnOpenCA.Click += OnOpenCurrentAccount;
            BtnSelectAcc.Click += OnSelectAccount;
            BtnRemoveAcc.Click += OnRemoveAccount;
            BtnDeposit.Click += OnDepositClicked;
            BtnWithdraw.Click += OnWithDrawClicked;
            BtnTransfer.Click += OnTransferClicked;
            BtnClose.Click += OnCloseClicked;
        }

        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            if (selectedAccount == null)
                MessageBox.Show("Please choose account");
            else
            {
                try
                {
                    var amount = selectedAccount.CloseAccount();
                    LoadAccountDetails(selectedAccount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnTransferClicked(object sender, RoutedEventArgs e)
        {
            int amount = 0;
            var result = ValidateAmount(out amount);
            if (true == result)
            {
                if (ComboBoxToAccounts.SelectedIndex < 0)
                    MessageBox.Show("Please choose account to transfer amount");
                else
                {
                    try
                    {
                        ITransaction accTransaction = (ITransaction)selectedAccount;
                        var accountNo = (long)ComboBoxToAccounts.SelectedItem;
                        var toAccount = accounts[accountNo];
                        if (selectedAccount == toAccount)
                            MessageBox.Show("Plese choose different account");
                        else
                        {
                            accTransaction.TransferAmount(toAccount, amount);
                            LoadAccountDetails(selectedAccount);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void OnWithDrawClicked(object sender, RoutedEventArgs e)
        {

            int amount = 0;
            var result = ValidateAmount(out amount);
            if (true == result)
            {
                try
                {
                    selectedAccount.Withdrawal(amount);
                    LoadAccountDetails(selectedAccount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void OnDepositClicked(object sender, RoutedEventArgs e)
        {

            int amount = 0;
            var result = ValidateAmount(out amount);
            if (true == result)
            {
                try
                {
                    selectedAccount.Deposit(amount);
                    LoadAccountDetails(selectedAccount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void OnSelectAccount(object sender, RoutedEventArgs e)
        {
            if (ComboBoxAccounts.SelectedIndex < 0)
                MessageBox.Show("Please choose a current account");
            else
            {
                var accountNo = (long)ComboBoxAccounts.SelectedItem;
                selectedAccount = accounts[accountNo];
                LoadAccountDetails(selectedAccount);
            }
        }

        private void OnRemoveAccount(object sender, RoutedEventArgs e)
        {
            if (ComboBoxAccounts.SelectedIndex < 0)
                MessageBox.Show("Please choose a current account");
            else
            {
                var accountNo = (long)ComboBoxAccounts.SelectedItem;
                var account = accounts[accountNo];
                try
                {
                    account.RemoveAccount();
                    RemoveAccount(account);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnOpenCurrentAccount(object sender, RoutedEventArgs e)
        {
            int openingBalance = 0;
            var result = ValidateOpenAccount(out openingBalance);
            if (true == result)
            {
                try
                {
                    var curAcc = new CurrentAccount(TbName.Text, openingBalance);
                    curAcc.OpenAccount();
                    AddAccount(curAcc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnOpenSavingAccount(object sender, RoutedEventArgs e)
        {
            int openingBalance = 0;
            var result = ValidateOpenAccount(out openingBalance);
            if (true == result)
            {
                try
                {
                    var savingAccount = new SavingAccount(TbName.Text, openingBalance);
                    savingAccount.OpenAccount();
                    AddAccount(savingAccount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool ValidateOpenAccount(out int OpeningBalance)
        {
            bool result = false;
            OpeningBalance = 0;
            if (string.IsNullOrWhiteSpace(TbName.Text))
                MessageBox.Show("Please enter Name");
            else if (string.IsNullOrWhiteSpace(TbOpenBalance.Text))
                MessageBox.Show("Please enter opening balance");
            else if (false == int.TryParse(TbOpenBalance.Text, out OpeningBalance))
                MessageBox.Show("Please enter valid integer value");
            else
                result = true;
            return result;
        }

        private bool ValidateAmount(out int Amount)
        {
            bool result = false;
            Amount = 0;
            if (selectedAccount == null)
                MessageBox.Show("Please select account");
            else if (string.IsNullOrWhiteSpace(TbDepWdAmount.Text))
                MessageBox.Show("Please enter Amount");
            else if (false == int.TryParse(TbDepWdAmount.Text, out Amount))
                MessageBox.Show("Please enter valid integer value");
            else
                result = true;
            return result;
        }

        private void AddAccount(Account account)
        {
            var accDetails = account.GetAccountDetails();
            var accNo = accDetails.AccountNo;
            ComboBoxAccounts.Items.Add(accNo);
            ComboBoxToAccounts.Items.Add(accNo);
            ComboBoxAccounts.SelectedItem = accNo;
            this.accounts.Add(accDetails.AccountNo, account);
        }

        private void RemoveAccount(Account account)
        {
            var accDetails = account.GetAccountDetails();
            var accNo = accDetails.AccountNo;
            ComboBoxToAccounts.Items.Remove(accNo);
            ComboBoxAccounts.Items.Remove(accNo);
            accounts.Remove(accNo);
        }

        private void LoadAccountDetails(Account account)
        {
            var accDetails = account.GetAccountDetails();
            TextBlockAccDetails.DataContext = accDetails;
        }

        private Dictionary<Int64, Account> accounts;
        private Account selectedAccount;
    }
}
