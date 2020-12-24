A=[106 59 8 70 6 19 49 6 13 44;
    59 152 33 111 61 96 8 78 70 83;
    8 33 104 20 21 66 45 6 54 81;
    70 111 20 148 17 109 36 63 22 32;
    6 61 21 17 49 40 7 25 58 49;
    19 96 66 109 40 133 47 59 60 55;
    49 8 45 36 7 47 152 12 39 46;
    6 78 6 63 25 59 12 123 52 30;
    13 70 54 22 58 60 39 52 111 84;
    44 83 81 32 49 55 46 30 84 144;
];
b=[154; 13; 64; 37; 125; 27; 10; 91; 136; 60];

tic
[n,m] = size(A);
for k = 1:n
    if A(k,k) == 0
        disp('error, A(k,k)==0');
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