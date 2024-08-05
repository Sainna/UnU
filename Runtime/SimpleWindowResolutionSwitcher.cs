using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sainna.Utils
{
    public class SimpleWindowResolutionSwitcher : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _resdropdown = null;

        [SerializeField] private Toggle _fullscreentoggle = null;


        private void Start()
        {
            bool isInBorderless = Screen.fullScreenMode == FullScreenMode.MaximizedWindow && Screen.fullScreen == true;
            _fullscreentoggle.isOn = isInBorderless;

            var selected = _resdropdown.options[_resdropdown.value];

            var xPos = selected.text.LastIndexOf('x');
            for (var index = 0; index < _resdropdown.options.Count; index++)
            {
                var data = _resdropdown.options[index];
                int width = 1280;
                int.TryParse(selected.text.Substring(0, xPos), NumberStyles.Integer, CultureInfo.CurrentCulture,
                    out width);
                if (Screen.width == width)
                {
                    _resdropdown.value = index;
                    break;
                }
            }
        }

        public void SetWindowSize(int selection)
        {
            int width = Screen.width / 2;
            int height = Screen.height / 2;
            var option = _resdropdown.options[selection];

            var xPos = option.text.LastIndexOf('x');

            int.TryParse(option.text.Substring(0, xPos), NumberStyles.Integer, CultureInfo.CurrentCulture, out width);
            int.TryParse(option.text.Substring(xPos + 1), NumberStyles.Integer, CultureInfo.CurrentCulture, out height);

            Screen.SetResolution(width, height, FullScreenMode.Windowed);
        }

        public void SetBorderlessFullscreen(bool v)
        {
            if (v)
            {
                Screen.SetResolution(Screen.mainWindowDisplayInfo.width, Screen.mainWindowDisplayInfo.height,
                    FullScreenMode.FullScreenWindow);
            }
            else
            {
                SetWindowSize(_resdropdown.value);
            }
        }


        public void InverseBoolInteractable(bool v)
        {
            _resdropdown.interactable = !v;
        }
    }
}