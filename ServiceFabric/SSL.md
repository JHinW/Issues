# SSL configure in Servie fabric



```xml
<Principals>
    <Users>
      <User Name="ServiceNetworkService" AccountType="NetworkService" />
    </Users>
  </Principals>
<Policies>
    <SecurityAccessPolicies>
      <SecurityAccessPolicy ResourceRef="SecretsCert" PrincipalRef="ServiceNetworkService" />
    </SecurityAccessPolicies>
  </Policies>

  <Certificates>
    <SecretsCertificate X509StoreName="MY" X509FindValue="[Secrets-Certificate-Find-Value]" Name="SecretsCert" />
  </Certificates>
```