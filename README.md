# Blockchain

A simple implementation of a blockchain, managed by a set of miners. Blockchain "guarantees" the order of a given set of event, alowing solving the double spending problem (if these events are transations).

Cycle:
* Data (digitally signed) is sent to the Unconfirmed Data (which is a FIFO);
* A Miner takes a data entry;
* Miner solves function, in this project a simple Left(Hash(block, nounce), 3) < x. For bitcoin this takes around ~10 minutes;
* Miner broadcasts block
* Nodes receive the block, confirm the integrity of the block, and add it to their chain;
* In case of forks in the chain, the longest chain should be maintained, and the other blocks sent back to the Unconfirmed Transactions.

Four main classes:
* __Block__, data class, only properties;
* __BlockFactory__, class that generates blocks;
* __HashEstimator__, responsible for the estimation of hashes;
* __Blockchain__, .

## Overview


Digital signature guarantees authentication, non-repudiation, and integrity.

Steps:
