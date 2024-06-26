﻿using System.Linq.Expressions;
using iBudget.DAO.Entities;
using iBudget.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared;

namespace iBudget.Business;

public class CompanyBusiness
{
    private readonly CompanyRepository _repository;

    public CompanyBusiness(CompanyRepository companyRepository)
    {
        _repository = companyRepository;
    }

    public async Task AddAsync(CompanyModel company)
    {
        await _repository.AddAsync(company);
    }

    public async Task<CompanyModel> GetByIdAsync(int companyId)
    {
        CompanyIncludes[] includes = { CompanyIncludes.None };
        return await _repository.GetByIdAsync(companyId, includes.Cast<Enum>().ToArray());
    }

    public async Task UpdateAsync(CompanyModel company)
    {
        CompanyIncludes[] includes = { CompanyIncludes.None };
        var existentCompany = await _repository.GetByIdAsync(
            company.CompanyId,
            includes.Cast<Enum>().ToArray()
        );

        if (existentCompany != null)
        {
            if (company.ImageFile != null) existentCompany.ImageFile = company.ImageFile;

            existentCompany.CompanyName = company.CompanyName;
            existentCompany.Address = company.Address;
            existentCompany.CNPJ = company.CNPJ;
            existentCompany.Email = company.Email;
            existentCompany.Phone = company.Phone;
        }

        await _repository.UpdateAsync(existentCompany);
    }

    public async Task RemoveAsync(int companyId)
    {
        CompanyIncludes[] includes = { CompanyIncludes.None };
        var company = await _repository.GetByIdAsync(
            companyId,
            includes.Cast<Enum>().ToArray()
        );
        if (company == null) return;

        await _repository.RemoveAsync(company);
    }

    public async Task<IEnumerable<CompanyModel>> FindAsync(
        Expression<Func<CompanyModel, bool>> where
    )
    {
        return await _repository.Find(where).ToListAsync();
    }

    public async Task<IEnumerable<CompanyModel>> FindAsync(
        Expression<Func<CompanyModel, bool>> where,
        CompanyIncludes[] includes
    )
    {
        return await _repository.FindAsync(where, includes.Cast<Enum>().ToArray());
    }

    public async Task<CompanyModel> GetAllAsync()
    {
        CompanyIncludes[] includes = { CompanyIncludes.None };
        IEnumerable<CompanyModel> companies = await _repository
            .GetAll(includes.Cast<Enum>().ToArray())
            .ToListAsync();

        if (companies.IsNullOrEmpty())
            throw new ECompanyBusinessException(Messages.CompanyNotFoundMessage);

        return companies?.FirstOrDefault();
    }
}