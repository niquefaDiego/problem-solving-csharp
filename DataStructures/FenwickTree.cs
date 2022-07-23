namespace DataStructures;

class BIT<T> {
  T[] a;

  Func<T,T,T> merge;
  T identity;

  public void update(int i, T x) {
      for (i++; i < a.Length; i += i&-i)
          a[i] = merge(a[i], x);
  }

  public T query(int i) {
      T r = identity;
      for (i++; i > 0; i -= i&-i)
          r = merge(r, a[i]);
      return r;
  }

  public BIT(int n, Func<T,T,T> merge, T identity) {
      a = new T[n+1];
      this.merge = merge;
      this.identity = identity;
  }
}
