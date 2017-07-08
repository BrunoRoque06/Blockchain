# Blockchain

Work in progress...

A simple implementation of a blockchain.

Four main classes:
* __Block__, data class, only properties;
* __BlockFactory__, class that generates blocks;
* __HashEstimator__, responsible for the estimation of hashes;
* __Blockchain__, .

## To Do

Blockchain "guarantees" the order of transactions, thus solving the double spending problem.
Digital signature guarantees authentication, non-repudiation, and integrity.

Steps:
* A transaction (digitally signed) is sent to the Unconfirmed Transactions (FIFO);
* Miner takes transaction (s);
* Miner solves function, for example Left(Hash(block, random_number), 3) < x. For bitcoin this takes around ~10 minutes;
* Miner broadcasts block
* Nodes receive the block, confirm the integrity of the block, and add it to their chain;
* In case of forks in the chain, the longest chain should be maintained, and the other blocks sent back to the Unconfirmed Transactions.
