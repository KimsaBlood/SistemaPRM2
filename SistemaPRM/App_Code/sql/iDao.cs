using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for iDao
/// </summary>
public interface iDao<T,K> 
{
    Boolean subir(T objeto);
    Boolean subir();
    Boolean cambios(K id,T objeto);
    IList<T> traeTodos();
    T traeUno(K id);
    Boolean elimina(K id);
    IList<T> traeVarios(K id);
}