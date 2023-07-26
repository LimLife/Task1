import React, { useState, useEffect } from "react";
import Company from "../Interfaces/Company";
import Data from "../ReturnData";
import checkmark from "../img/check.png";
import { REST } from "../Enums/REST";
const Companies: React.FC<{ id: number }> = ({ id }) =>
{
    const [company, setCompany] = useState<Company>();
    useEffect(() =>
    {
        const data = async () =>
        {
            const company = await Data<Company>(`/company/companybyid/${id}`, REST.GET)
            if (company !== null)
                setCompany(company);
        }
        data();
    }, []);
    return (
        <>
            <div>
                <div className="row">
                    <span className="text-col-bl-size-20">
                        Info
                    </span>
                    <div>
                        <button className="btn" title="just click" type="button">
                            <img src={checkmark} alt="check mark" width={20} height={20} />
                        </button>
                    </div>
                </div>
                <dl className="row ">
                    <dt>ID:</dt>
                    <dd className="border-all-1-green">{company?.id}</dd>
                </dl>
                <dl className="row">
                    <dt>Name:</dt>
                    <dd className="border-all-1-green">{company?.companyName}</dd>
                </dl>
                <dl className="row">
                    <dt>Address:</dt>
                    <dd className="border-all-1-green">{company?.address}</dd>
                </dl>
                <dl className="row">
                    <dt>City:</dt>
                    <dd className="border-all-1-green">{company?.city}</dd>
                </dl> <dl className="row">
                    <dt>Phone:</dt>
                    <dd className="border-all-1-green">{company?.phone}</dd>
                </dl>
            </div>
        </>
    )
}
export default Companies;