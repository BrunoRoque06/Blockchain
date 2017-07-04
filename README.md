# Blockchain

A simple implementation of a blockchain.

Four main classes:
* __Block__, data class, only properties;
* __BlockFactory__, class that generates blocks;
* __HashEstimator__, responsible for the estimation of hashes;
* __Ledger__, contains the blockchain itself.

Right now, it's not possible to add unvalidated blocks to the chain.