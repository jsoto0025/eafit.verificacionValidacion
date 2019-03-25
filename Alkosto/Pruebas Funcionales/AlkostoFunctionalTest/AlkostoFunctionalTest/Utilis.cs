using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkostoFunctionalTest
{
    /// <summary>
    /// Utilidades requeridas para las purebas funcionales.
    /// </summary>
    public static class Utilis
    {
        public const string screenShotsDirectoryName = "ScreeShots";

        /// <summary>
        /// Toma una captura de pantalla
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="classTestName"></param>
        public static void TakeScreenShot(IWebDriver driver, string classTestName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            if (!Directory.Exists(Utilis.screenShotsDirectoryName))
            {
                Directory.CreateDirectory(Utilis.screenShotsDirectoryName);
            }

            string fileName = Utilis.screenShotsDirectoryName + @"\" + classTestName + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".jpg";

            ss.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }
    }
    
}
