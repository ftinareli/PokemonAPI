using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.View
{
    internal class Menu
    {
        public static string MenuLogo()
        {
            return @"
 #######                                                                    
    #       ##    #    #    ##     ####    ####   #####   ####   #    #  # 
    #      #  #   ##  ##   #  #   #    #  #    #    #    #    #  #    #  # 
    #     #    #  # ## #  #    #  #       #    #    #    #       ######  # 
    #     ######  #    #  ######  #  ###  #    #    #    #       #    #  # 
    #     #    #  #    #  #    #  #    #  #    #    #    #    #  #    #  # 
    #     #    #  #    #  #    #   ####    ####     #     ####   #    #  #";
        }
        public static string MenuLateral(char caractere)
        {
            return $"|{new string(caractere, 73)}|";
        }
        public static string MenuComString(string variavel, char caractere)
        {
            return $"|{variavel}{new string(caractere, 73 - variavel.Length)}|";
        }
    }
}
