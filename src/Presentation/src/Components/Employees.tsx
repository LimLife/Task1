import Employee from "../Interfaces/Employee";
import React, { useEffect, useState } from "react";
import Data from "../ReturnData";
import CuretEmployee from "./CuretEmployee";
import update from "../img/update.png";
import pen from "../img/pen.png";
import plus from "../img/plus.png";
import { REST } from "../Enums/REST";



const Employees: React.FC<{ id: number }> = ({ id }) =>
{
    const [employee, setEmployee] = useState<Employee[]>([]);

    const [person, setPerson] = useState<number>(0);
    const data = async () =>
    {
        const employee = await Data<Employee[]>(`/company/employeescompany/${id}`, REST.GET);
        if (employee !== null)
            setEmployee(employee);
    }
    useEffect(() =>
    {
        data();
    }, []);
    return (<>
        <div className="row ">
            <div>
                <div className="row">
                    <span className="text-col-bl-size-20">Employee</span>
                    <div className="item-right">
                        <button className="btn" title="just click" type="button">
                            <img src={plus} alt="check mark" width={20} height={20} />
                        </button>
                        <button className="btn" title="save" type="button">
                            <img src={pen} alt="check mark" width={20} height={20} />
                        </button>
                        <button onClick={data} className="btn" title="update" type="button">
                            <img src={update} alt="check mark" width={20} height={20} />
                        </button>
                    </div>
                </div>
                <div className="row">
                    <span>First Name:</span>
                    <span>Last Name:</span>
                </div>
                {employee?.map((item) => (
                    <dl key={item.id} className="row" >
                        <dt onClick={() => setPerson(item.id)}>{item.firstName}</dt>
                        <dd>{item.lastName}</dd>
                    </dl>
                ))}
            </div>
            <div>
                <CuretEmployee id={person} />
            </div>
        </div>
    </>)
}
export default Employees;