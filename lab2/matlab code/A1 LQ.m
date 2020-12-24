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

I = zeros(n,m);
for i=1:n
    for j=1:n
        if i==j
            I(i,j)=1;
        end
    end
end

mu = 0;
beta = 0;
w = zeros(n,1);

Qt = zeros(n,m);
H = zeros(n, m);

for i=1:n-1
    sum = 0;
    for k=i:n
        sum+=power(A(i,k),2);
    end
    if sign(-A(i,i)) == -1
        beta=-sqrt(sum);
    else 
        beta=sqrt(sum);
    end
    mu=1/sqrt(2*power(beta, 2)-2*beta*A(i,i));
    for j=1:n
        w(j)=mu*A(i,j);
        if j==i
            w(j)= w(j)-mu * beta;
        end
        if i~=1
            for k=1:i-1
                w(k)=0;
            end
        end
        
    end
    
    H=I-2*w*w';
    
    if i==1
        Qt=H;
    else
        Qt=Qt*H;
    end

    A = A*H;
end

y=A\b;
y
    
x=Qt*y;
x

toc