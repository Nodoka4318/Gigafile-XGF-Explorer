using Xgf;

var explorer = Explorer.GetExplorer();
for (; ;) {
    await explorer.SearchOneAsync();
}