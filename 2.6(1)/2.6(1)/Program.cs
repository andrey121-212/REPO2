using System;

namespace BankApp
{
    public class BankAccount
    {
        private readonly string _accountNumber;
        private string _ownerName;
        private decimal _balance;

        public BankAccount(string ownerName, decimal initialBalance = 0m)
        {
            if (string.IsNullOrWhiteSpace(ownerName))
            {
                throw new ArgumentException("Имя владельца счета не может быть пустым.", nameof(ownerName));
            }
            if (initialBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Начальный баланс не может быть отрицательным.");
            }

            _accountNumber = Guid.NewGuid().ToString("N").Substring(0, 16); // Уникальный номер счета
            _ownerName = ownerName;
            _balance = initialBalance;

            Console.WriteLine($"Создан новый банковский счет: №{AccountNumber}, Владелец: {OwnerName}, Баланс: {Balance:C}");
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
        }

        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имя владельца счета не может быть пустым.", nameof(OwnerName));
                }
                _ownerName = value;
                Console.WriteLine($"Имя владельца счета {AccountNumber} изменено на: {_ownerName}");
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            private set // Баланс можно менять только через методы класса
            {
                _balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма пополнения должна быть положительным числом.");
            }

            Balance += amount;
            Console.WriteLine($"Счет {AccountNumber}: Пополнено на {amount:C}. Текущий баланс: {Balance:C}");
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма снятия должна быть положительным числом.");
            }

            if (amount > Balance)
            {
                Console.WriteLine($"Ошибка: Недостаточно средств на счете {AccountNumber}. Требуется: {amount:C}, доступно: {Balance:C}");
                return false;
            }

            Balance -= amount;
            Console.WriteLine($"Счет {AccountNumber}: Снято {amount:C}. Текущий баланс: {Balance:C}");
            return true;
        }

        public bool Transfer(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                throw new ArgumentNullException(nameof(targetAccount), "Целевой счет не может быть null.");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма перевода должна быть положительным числом.");
            }

            if (this.Withdraw(amount))
            {
                targetAccount.Deposit(amount);
                Console.WriteLine($"Счет {AccountNumber}: Переведено {amount:C} на счет {targetAccount.AccountNumber}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Счет {AccountNumber}: Не удалось перевести {amount:C} на счет {targetAccount.AccountNumber} (недостаточно средств).");
                return false;
            }
        }

        public override string ToString()
        {
            return $"Банковский счет:\n" +
                   $"  Номер счета: {AccountNumber}\n" +
                   $"  Владелец: {OwnerName}\n" +
                   $"  Баланс: {Balance:C}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Создание банковских счетов ---");
            try
            {
                BankAccount account1 = new BankAccount("Иван Иванов", 1000.50m);
                BankAccount account2 = new BankAccount("Петр Петров");
                BankAccount account3 = new BankAccount("Мария Сидорова", 500m);

                Console.WriteLine("\n--- Информация о созданных счетах ---");
                Console.WriteLine(account1);
                Console.WriteLine(account2);
                Console.WriteLine(account3);

                Console.WriteLine("\n--- Операции с первым счетом ---");
                Console.WriteLine($"Текущий баланс счета {account1.AccountNumber}: {account1.Balance:C}");
                account1.Deposit(250.75m);
                account1.Withdraw(100m);
                account1.Withdraw(1500m); // Попытка снять больше

                Console.WriteLine("\n--- Установка нового имени владельца ---");
                account1.OwnerName = "Иван Петрович Иванов";
                Console.WriteLine($"Обновленное имя владельца счета {account1.AccountNumber}: {account1.OwnerName}");

                Console.WriteLine("\n--- Перевод средств между счетами ---");
                Console.WriteLine($"Баланс до перевода: Счет 1 - {account1.Balance:C}, Счет 2 - {account2.Balance:C}");
                if (account1.Transfer(account2, 300m))
                {
                    Console.WriteLine("Перевод успешно выполнен.");
                }
                else
                {
                    Console.WriteLine("Перевод не удался.");
                }
                Console.WriteLine($"Баланс после перевода: Счет 1 - {account1.Balance:C}, Счет 2 - {account2.Balance:C}");

                Console.WriteLine("\n--- Повторная попытка перевода (недостаточно средств) ---");
                if (account3.Transfer(account1, 1000m))
                {
                    Console.WriteLine("Перевод успешно выполнен.");
                }
                else
                {
                    Console.WriteLine("Перевод не удался.");
                }
                Console.WriteLine($"Баланс после попытки перевода: Счет 3 - {account3.Balance:C}, Счет 1 - {account1.Balance:C}");

                Console.WriteLine("\n--- Итоговая информация о счетах ---");
                Console.WriteLine(account1);
                Console.WriteLine(account2);
                Console.WriteLine(account3);

                // --- Тестирование некорректных входных данных ---
                Console.WriteLine("\n--- Тестирование некорректных входных данных ---");
                try
                {
                    BankAccount invalidAccountByName = new BankAccount("");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка при создании счета с пустым именем: {ex.Message}");
                }

                try
                {
                    BankAccount invalidAccountByBalance = new BankAccount("Тест", -100m);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка при создании счета с отрицательным балансом: {ex.Message}");
                }

                try
                {
                    account1.Deposit(-50m);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка при пополнении на отрицательную сумму: {ex.Message}");
                }

                try
                {
                    account1.Withdraw(0m);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка при снятии нулевой суммы: {ex.Message}");
                }

                try
                {
                    account1.Transfer(null, 100m);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Ошибка при переводе на null счет: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
