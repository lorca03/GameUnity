using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntuacionController : MonoBehaviour
{
    int eliminacionesConsecutivas = 0;
    int puntosPorEliminacion = 10;
    int eliminacionesParaCombo = 3;

    void EnemyEliminated()
    {
        eliminacionesConsecutivas++;
    }

}
