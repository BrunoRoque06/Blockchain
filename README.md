# Blockchain

## Overview
This project is a simple implementation of a blockchain, managed by a group of miners. Blockchain is a tecnology that "guarantees" the order of a given set of events, and is used in tecnologies such as Bitcoin and Ethereum. If these events are transactions (Bitcoin), it solves the double spending problem. Another important element of these systems is Digital Signature, which guarantees authentication, non-repudiation, and integrity.

Routine:
* Data (digitally signed) is sent to the Unconfirmed Data (a FIFO queue);
* A Miner takes an unconfirmed data entry;
* Miner solves a "Proof of Work" problem, in this project a simple Left(Hash(block, nonce), 3) < 100. Function used for Bitcoin takes around ~10 minutes/block to find a correct value for "nonce" property;
* Miner broadcasts block;
* Other miners receive the block, confirm the integrity of the block (hash validation), and add it to their blockchain;
* If the block is not validated (hash), miners won’t add it to their blockchain and wont broadcast it;
* In case of forks in the chain, the longest chain should be maintained, and the other blocks sent back to the Unconfirmed Transactions.

Main classes:
* __Block__, only has properties;
* __Blockchain__, list of blocks;
* __BlockFactory__, class that generates blocks;
* __HashEstimator__, responsible for hash estimation;
* __UnconfirmedDataFifo__, FIFO queue, with the unconfirmed data;
* __Miner__, responsible for getting data, solving blocks, and broadcasting them. 

## UML
![umlblockchain](https://user-images.githubusercontent.com/28269891/28410554-efd2c1b8-6d35-11e7-9da1-1839b397ee2f.png)

