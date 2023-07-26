import React, { useEffect, useState } from "react";
import Company from "./Interfaces/Company";
import "../src/site.css";
import { REST } from "./Enums/REST";
import Data from "./ReturnData";

const Main: React.FC = () =>
{
    const [companies, setCompanies] = useState<Company[]>([]);

    useEffect(() =>
    {
        const data = async () =>
        {
            const company = await Data<Company[]>("/company/companies", REST.GET);
            if (company !== null)
                setCompanies(company)
        }
        data();
    }, [companies]);

    return (
        <div className="container-grid">
            <table>
                <thead>
                    <tr>
                        <th className="table-name" colSpan={0}>CompanyName</th>
                    </tr>
                    <tr>
                        <th>Company Name</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Phone</th>
                    </tr>
                </thead>
                <tbody>
                    {companies.map((company) => (
                        <tr key={company.id}>
                            <td>
                                <a href={`/Details/${company.id}/${company.companyName}`} target="_blanc">{company.companyName}</a>
                            </td>
                            <td>{company?.city}</td>
                            <td>{company?.state}</td>
                            <td>{company?.phone}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default Main;