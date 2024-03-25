namespace EvidenceKoni.Models
{
    public class Pager
    {
        /// <summary>
        /// Součet všech položek
        /// </summary>
        public int TotalItems { get; private set; }
        /// <summary>
        /// Uložení aktuální strany
        /// </summary>
        public int CurrentPage { get; private set;}
        /// <summary>
        /// Velikost stránky ve smyslu počtu položek na stránku
        /// </summary>
        public int PageSize { get; private set;}

        /// <summary>
        /// Celkový počet stránek
        /// </summary>
        public int TotalPages { get; private set;}
        /// <summary>
        /// Počáteční strana pageru
        /// </summary>
        public int StartPage { get; private set;}
        /// <summary>
        /// Polsední strana pageru
        /// </summary>
        public int EndPage { get; private set;}

        /// <summary>
        /// Prázdný konstruktor pro případ 0 záznamů
        /// </summary>
        public Pager()
        {

        }

        /// <summary>
        /// Konstruktor v případě přítomnosti záznamů včetně logiky pro zobrazení
        /// a ošetření překročení stránkování
        /// </summary>
        /// <param name="totalItems">Celkový počet položek</param>
        /// <param name="page">Aktuální strana</param>
        /// <param name="pageSize">Počet položek na stránku</param>
        public Pager(int totalItems, int page, int pageSize = 10)
        {
            int totalPages =(int)Math.Ceiling((decimal)totalItems/(decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(startPage < 0)
            {
                endPage -= (startPage -1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            // Přířazení hodnot do proměnných
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
        
    }
}
