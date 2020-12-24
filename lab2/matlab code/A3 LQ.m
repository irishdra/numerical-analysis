A=[150 -52 0 0 0 0 0 0 0 0;
    19 -87 33 0 0 0 0 0 0 0;
    0 -212 442 77 0 0 0 0 0 0;
    0 0 -8 -123 -47 0 0 0 0 0;
    0 0 0 -110 630 -160 0 0 0 0;
    0 0 0 0 -39 -315 15 0 0 0;
    0 0 0 0 0 -13 124 -13 0 0;
    0 0 0 0 0 0 5 31 14 0;
    0 0 0 0 0 0 0 -44 445 148;
    0 0 0 0 0 0 0 0 -643 -732;
];
b=[-832; -673; -352; -397; -977; 80; -810; -707; 262; 719];

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
    
x=Qt*y;

toc
disp(num2str(x,16))