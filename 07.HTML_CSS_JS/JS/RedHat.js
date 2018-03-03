getMaxPathDfs() {
    var getBestFrom = (node, currentPath, parent) => {
        // use node

        var best = {
            path: currentPath,
            node: node
        };

        this.nodes[node]
            .filter((next) => next !== parent)
            .forEach((next) => {
                var current = getBestFrom(next, currentPath + this.weights[next], node);

                if (current.path > best.path) {
                    best.path = current.path;
                    best.node = current.node;
                }
            });

        return best;
    };
    var node = this.nodes
        .slice(1)
        .findIndex((children) => {
            return children.length === 1;
        });

    node += 1;

    var best = getBestFrom(node, this.weights[node], -1);

    best = getBestFrom(best.node, this.weights[best.node], -1);
    return best.path;
}
