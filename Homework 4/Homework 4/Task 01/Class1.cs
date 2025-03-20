
namespace Task_01
{
    public class User
    {
      public string Username { get; set; }
      public string CardNumber { get; set; }
      private int _pin { get; set; }
      private int _balance { get; set; }

        
      public int GetPin()
      {
          return _pin;
      }  
      public void SetPin(int pin)
      {
          _pin = pin;
      }  
      public int GetBalance()
      {
          return _balance;
      }  
      public void SetBalance(int balance)
      {
          _balance = balance;
      }
    }
}
