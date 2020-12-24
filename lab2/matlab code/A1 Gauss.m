A=[-68 -18 95 -91 -55 67 -64 1 -63;
    60 35 -73 84 66 -5 87 24 -43;
    -96 15 -85 77 -91 -38 75 -31 50;
    -74 70 -42 -48 96 12 -41 -23 84;
    -42 -64 47 -61 12 66 15 95 -89;
    -65 -24 -33 63 -91 39 -22 -50 41;
    40 -25 -32 -75 -93 67 -74 -21 -42;
    -87 -60 -22 25 51 -94 5 59 15;
    -20 -72 88 79 92 52 8 -79 -36;
];
b=[-54; -98; -54; -43; 88; 89; -52; 69; -48];

tic
[n,m] = size(A);
for k = 1:n
    if A(k,k) == 0
        disp('A(k,k)=0');
        return;
    end
    mainEl = A(k, k);
    for j = k:n
       A(k,j) = A(k,j)/mainEl; 
    end
    b(k) = b(k)/mainEl;
    
    for j=k+1:n
       buffA = A(j,k);
       for l=k:n
          A(j,l) = A(j,l) - (buffA*A(k,l)); 
       end
       b(j) = b(j) - (b(k)*buffA);
    end
    k
    A
    b
end

x = zeros(n,1);
for i=n:-1:1
   acc = b(i);
   for j=n:-1:i+1
      acc = acc - (A(i,j)*x(j)); 
   end
   x(i) = acc;
end
    x
    toc

disp(num2str(x, 16));