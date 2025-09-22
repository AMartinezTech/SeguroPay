namespace MotoStock.Utils.Factories;

public interface IFormFactory
{
    T CreateFormFactory<T>() where T : Form; 
}
