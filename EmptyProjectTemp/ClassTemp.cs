using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EmptyProjectTemp {
    public class ClassTemp {
        public static void Main(string[] args) {
            //对于反射的学习
            ITank tank = new HeavyTank();
            //======华丽的分割线=======
            Type t = tank.GetType();//获得tank类对应的type
            Object o = Activator.CreateInstance(t);//从Type出发利用激活器来创建实例
            //从Type出发，获取某个类的方法的信息
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo RunMi = t.GetMethod("Run");

            //将方法和实例绑定，调用方法
            fireMi.Invoke(o, null);
            RunMi.Invoke(o, null);
            Console.WriteLine();



            //依赖注入相关学习
            var sc = new ServiceCollection();//容器,ServiceCollection(用来装载“服务”，即各种接口，类型)
            sc.AddScoped(typeof(ITank), typeof(HeavyTank));

            var sp = sc.BuildServiceProvider();//ServiceProvider（用来提供“服务”）
            //===========华丽的分割线==========
            ITank tank1 = sp.GetService<ITank>();
            tank1.Fire();
            tank1.Run();
            Console.ReadLine();

        }
    }

    class Driver {
        private IVehicle vehicle;
        public Driver(IVehicle vehicle) {
            this.vehicle = vehicle;
        }

        public void Drive() {
            vehicle.Run();
        }
    }

    interface IVehicle {
        void Run();
    }

    interface IWeapon {
        void Fire();
    }

    interface ITank : IWeapon, IVehicle {

    }

    class Car : IVehicle {
        public void Run() {
            Console.WriteLine("the car is running");
        }
    }

    class HeavyTank : ITank {
        public void Fire() {
            Console.WriteLine("Boommmmm!");
        }

        public void Run() {
            Console.WriteLine("ka ka ka");
        }
    }
}
