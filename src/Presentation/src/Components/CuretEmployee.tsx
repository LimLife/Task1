import { useState, useEffect } from "react";
import Employee from "../Interfaces/Employee";
import Data from "../ReturnData";
import trash from "../img/trash.png";
import pen from "../img/pen.png";
import { REST } from "../Enums/REST";


const CuretEmployee: React.FC<{ id: number }> = ({ id }) =>
{
    const [employee, setNote] = useState<Employee>();
    useEffect(() =>
    {
        const data = async () =>
        {
            const employee = await Data<Employee>(`/company/employee/${id}`, REST.GET);
            if (employee !== null)
                setNote(employee);
        }
        data();
    }, [id]);

    return (
        <>
            <div>
                <div className="row">
                    <div className="row">
                    </div>
                    <div className="item-right">
                        <button className="btn" title="just click" type="button">
                            <img src={trash} alt="check mark" width={20} height={20} />
                        </button>
                        <button className="btn" title="just click" type="button">
                            <img src={pen} alt="check mark" width={20} height={20} />
                        </button>
                    </div>
                </div>
                <dl className="row">
                    <dt>First Name:</dt>
                    <dd>{employee?.firstName}</dd>
                </dl>
                <dl className="row">
                    <dt>Last Name:</dt>
                    <dd>{employee?.lastName}</dd>
                </dl>
                <dl className="row">
                    <dt>Title:</dt>
                    <dd>{employee?.title}</dd>
                </dl>
                <dl className="row">
                    <dt>Birth Day:</dt>
                    <dd>{employee?.birthDate}</dd>
                </dl> <dl className="row">
                    <dt>Position:</dt>
                    <dd>{employee?.position}</dd>
                </dl>
            </div>
        </>
    );
}

export default CuretEmployee;