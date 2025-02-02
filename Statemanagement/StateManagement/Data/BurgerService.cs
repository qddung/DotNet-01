namespace StateManagement.Data;
using System;
using Microsoft.AspNetCore.Components;
using StateManagement.Models.View;

public class BurgerService
{
    private List<IncrementItem> ListInCrement {get;set;} = new List<IncrementItem>(){
        new IncrementItem(1, "Salad", 0, 20, "salad" ),
        new IncrementItem(2, "Cheese", 0, 40, "cheese" ),
        new IncrementItem(3, "Beef", 0, 55, "beef" ),
    };
    
    public List<IncrementItem> GetListInCrement() {
        return ListInCrement;
    }
    public void IncreateIncrement(int id){
        var increment = ListInCrement.FirstOrDefault(i => i.Id == id);
        if(increment != null){
            increment.Quantity++;
        }
        NotifyChange();
    }

    public int GetQuantity(int id){
        var data = ListInCrement.FirstOrDefault(i => i.Id == id);
        if(data != null){
            return data.Quantity;
        }
        return 0;
    }

    public void DecreaseIncrement(int id){
        var increment = ListInCrement.FirstOrDefault(i => i.Id == id);
        if(increment != null){
            if(increment.Quantity > 0) increment.Quantity--;
        }
        NotifyChange();
    }

    public event Action? OnChange;
    public void NotifyChange() {
        OnChange?.Invoke();
    }
}