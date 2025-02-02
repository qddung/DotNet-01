namespace StateManagement.Models.View;
public class IncrementItem {
    public IncrementItem(){

    }
    public IncrementItem(int id, string name, int quantity, int price, string className){
        Id = id; 
        Name = name;
        Quantity = quantity;
        Price = price;
        ClassName = className;
    }

    public int Id {get;set;}
    public string Name {get;set;}
    public int Price {get;set;}
    public int Quantity {get;set;} = 0;
    public int Total {get {
        return Price * Quantity;
    }}
    public string ClassName {get;set;}

}