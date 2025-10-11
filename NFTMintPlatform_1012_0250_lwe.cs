// 代码生成时间: 2025-10-12 02:50:25
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Util;

/// <summary>
/// NFT铸造平台
/// </summary>
public class NFTMintPlatform
{
    private Web3 web3;
    private Contract contract;
    private string contractAddress;
    private string abi;

    /// <summary>
    /// 构造函数，初始化Web3和合约
    /// </summary>
    /// <param name="contractAddress">合约地址</param>
    /// <param name="abi">合约ABI</param>
    public NFTMintPlatform(string contractAddress, string abi)
    {
        this.contractAddress = contractAddress;
        this.abi = abi;
        this.web3 = new Web3("neturl"); // 替换为实际的以太坊网络URL
        this.contract = web3.Eth.GetContract(abi, contractAddress);
    }

    /// <summary>
    /// 铸造NFT
    /// </summary>
    /// <param name="tokenURI">NFT的metadata URI</param>
    /// <returns>铸造成功的交易hash</returns>
    public async Task<string> MintNFTAsync(string tokenURI)
    {
        try
        {
            var function = contract.GetFunction("mint");
            // 调用合约的mint函数，传入tokenURI
            var transactionHash = await function.SendTransactionAndWaitForReceiptAsync(web3.TransactionManager.Account.Address, tokenURI);
            return transactionHash;
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to mint NFT: " + ex.Message);
            throw;
        }
    }

    /// <summary>
    /// 获取NFT的metadata
    /// </summary>
    /// <param name="tokenId">NFT的tokenId</param>
    /// <returns>NFT的metadata</returns>
    public async Task<string> GetNFTMetadataAsync(uint256 tokenId)
    {
        try
        {
            var function = contract.GetFunction("tokenURI");
            // 调用合约的tokenURI函数，传入tokenId
            return await function.CallAsync<string>(tokenId);
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to retrieve NFT metadata: " + ex.Message);
            throw;
        }
    }
}
