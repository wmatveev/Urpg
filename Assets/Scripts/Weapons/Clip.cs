namespace Weapons
{
    // Создание, пополнение обоймы
    public class Clip
    {
        private int _countBullets;

        public Clip(int countBullets)
        {
            _countBullets = countBullets;
        }

        // Добавляем патроны в обойму
        public void AddBullets(int count)
        {
            _countBullets += count;
        }

        // Удалить патрон из обоймы
        public void DeleteBullets(int count)
        {
            _countBullets -= count;
        }
        
        // Проверить количество патронов в обойме
        public bool CheckBulletsInClip()
        {
            return _countBullets > 0 ? true : false;
        }
    }
}