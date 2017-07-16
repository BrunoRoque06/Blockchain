# Blockchain

## Overview
This project consists on a simple implementation of a blockchain, managed by a set of miners. Blockchain "guarantees" the order of a given set of event. If these events are transations (Bitcoin), it solves the double spending problem. Another important element in these systems is Digital Signatures, which guarantees authentication, non-repudiation, and integrity.

Routine:
* Data (digitally signed) is sent to the Unconfirmed Data (which is a FIFO);
* A Miner takes an unconfirmed data entry;
* Miner solves function, in this project a simple Left(Hash(block, nonce), 3) < 100. Function used for Bitcoin takes around ~10 minutes/block;
* Miner broadcasts block;
* Other miners receive the block, confirm the integrity of the block (hash validation), and add it to their blockchain;
* If the block is not validated (hash), miners wont add it to their blockchain and wont broadcast it;
* In case of forks in the chain, the longest chain should be maintained, and the other blocks sent back to the Unconfirmed Transactions.

Main classes:
* __Block__, only has properties;
* __Blockchain__, list of blocks;
* __BlockFactory__, class that generates blocks;
* __HashEstimator__, responsible for hash estimation;
* __UnconfirmedDataFifo__, FIFO queue, with the unconfirmed data;
* __Miner__, responsible for geting data, solving blocks, and broadcasting them. 

## UML

