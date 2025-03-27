using UnityEngine;

public class Trigger_Handler : MonoBehaviour
{
    public static GameObject current_menu;

    public static void ChangeMenu(GameObject new_menu)
    {
        // If there’s a currently open menu, deactivate it
        if (current_menu)
        {
            current_menu.SetActive(false);
        }

        // Set the new menu as the current one
        current_menu = new_menu;

        // If the new menu is valid, activate it and trigger open animation
        if (current_menu)
        {
            current_menu.SetActive(true);

            // Grab the animator from the new menu (if any) and play the open animation
            Menu_Animator animator = current_menu.GetComponent<Menu_Animator>();
            if (animator != null)
            {
                animator.PlayOpenAnimation();
            }
            else
            {
                Debug.LogWarning("No MenuAnimator found on " + current_menu.name);
            }
        }
    }
}
