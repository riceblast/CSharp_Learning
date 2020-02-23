using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib {
   public class Calculator {
        public  int Add(int a, int b) {
            return (a + b);
        }

    }
    

    public class c : Calculator {
        public void m() {
            base.Add(1,2);
        }
    }
}
