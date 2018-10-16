# Blockchain

This project is a simple implementation of a Blockchain, managed by a group of miners. Blockchain is a tecnology that "guarantees" the order of a given set of events. If these events are bank transactions, it "solves" the double spending problem. Another important element of these systems is Digital Signature, which guarantees authentication, non-repudiation, and integrity.

Routine:

* Data (digitally signed) is sent to the Unconfirmed Data (a FIFO queue);
* A miner takes an unconfirmed data entry;
* Miner solves a "Proof of Work" problem, in this project a simple `Left(Hash(block, nonce), 3) < 100`. Function used for Bitcoin takes around ~10 minutes/block to find a correct value for `nonce` property;
* Miner broadcasts block;
* Other miners receive the block, confirm the integrity of the block (hash validation), and add it to their Blockchain;
* If the block is not validated (hash), miners won't add it to their Blockchain and won't broadcast it;
* In case of forks in the chain, the longest chain should be kept, and the other blocks sent back to the Unconfirmed Data.

Main classes:

* `Block`, only has properties;
* `Blockchain`, list of blocks;
* `BlockFactory`, class that generates blocks;
* `HashEstimator`, responsible for hash estimation;
* `UnconfirmedDataFifo`, FIFO queue, with the unconfirmed data;
* `Miner`, responsible for getting data, solving blocks, and broadcasting them.
