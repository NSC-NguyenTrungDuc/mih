package nta.med.orca.gw.api.unit;

import com.fasterxml.jackson.core.JsonGenerator;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.Version;
import com.fasterxml.jackson.databind.JsonSerializer;
import com.fasterxml.jackson.databind.SerializerProvider;
import com.fasterxml.jackson.databind.module.SimpleModule;
import com.fasterxml.jackson.dataformat.xml.JacksonXmlModule;
import com.fasterxml.jackson.dataformat.xml.XmlMapper;
import com.fasterxml.jackson.dataformat.xml.ser.ToXmlGenerator;
import nta.med.orca.gw.api.contracts.service.ShunouRequest;
import nta.med.orca.gw.api.contracts.wrapper.ShunouWrapper;
import org.junit.Test;

import java.io.IOException;

/**
 * @author dainguyen.
 */
public class XmlMapperTest {

    @Test
    public void testXmlResponseDeserialize() throws Exception {
        String data = "<xmlio2>\n" +
                "  <private_objects type=\"record\">\n" +
                "    <Information_Date type=\"string\">2013-12-11</Information_Date>\n" +
                "    <Information_Time type=\"string\">12:21:52</Information_Time>\n" +
                "    <Api_Result type=\"string\">0000</Api_Result>\n" +
                "    <Api_Result_Message type=\"string\">処理終了</Api_Result_Message>\n" +
                "    <Patient_Information type=\"record\">\n" +
                "      <Patient_ID type=\"string\">00012</Patient_ID>\n" +
                "      <WholeName type=\"string\">日医　太郎</WholeName>\n" +
                "      <WholeName_inKana type=\"string\">ニチイ　タロウ</WholeName_inKana>\n" +
                "      <BirthDate type=\"string\">1975-01-01</BirthDate>\n" +
                "      <Sex type=\"string\">1</Sex>\n" +
                "    </Patient_Information>\n" +


                "    <Income_Information_Overflow type=\"string\">false</Income_Information_Overflow>\n" +
                "    <Income_Information type=\"array\">\n" +
                "      <Income_Information_child type=\"record\">\n" +
                "        <Perform_Date type=\"string\">2013-10-01</Perform_Date>\n" +
                "        <InOut type=\"string\">2</InOut>\n" +
                "        <Invoice_Number type=\"string\">0000053</Invoice_Number>\n" +
                "        <Insurance_Combination_Number type=\"string\">0002</Insurance_Combination_Number>\n" +
                "        <Rate_Cd type=\"string\">  0</Rate_Cd>\n" +
                "        <Department_Code type=\"string\">01</Department_Code>\n" +
                "        <Department_Name type=\"string\">内科</Department_Name>\n" +
                "        <Cd_Information type=\"record\">\n" +
                "          <Ac_Money type=\"string\">         0</Ac_Money>\n" +
                "          <Ic_Money type=\"string\">         0</Ic_Money>\n" +
                "          <Ai_Money type=\"string\">         0</Ai_Money>\n" +
                "          <Oe_Money type=\"string\">         0</Oe_Money>\n" +
                "        </Cd_Information>\n" +
                "        <Ac_Point_Information type=\"record\">\n" +
                "          <Ac_Ttl_Point type=\"string\">      1800</Ac_Ttl_Point>\n" +
                "          <Ac_Point_Detail type=\"array\">\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">A00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">初・再診料</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">        69</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">B00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">医学管理等</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">C00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">在宅療養</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">F00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">投薬</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">        68</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">G00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">注射</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">J00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">処置</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">K00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">手術</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">      1663</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">L00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">麻酔</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">D00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">検査</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">E00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">画像診断</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">H00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">リハビリ</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">I00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">精神科専門</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">M00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">放射線治療</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">N00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">病理診断</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">A10</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">入院料</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "          </Ac_Point_Detail>\n" +
                "        </Ac_Point_Information>\n" +
                "      </Income_Information_child>\n" +
                "      <Income_Information_child type=\"record\">\n" +
                "        <Perform_Date type=\"string\">2013-10-08</Perform_Date>\n" +
                "        <Perform_End_Date type=\"string\">2013-10-09</Perform_End_Date>\n" +
                "        <InOut type=\"string\">1</InOut>\n" +
                "        <Invoice_Number type=\"string\">0000001</Invoice_Number>\n" +
                "        <Insurance_Combination_Number type=\"string\">0002</Insurance_Combination_Number>\n" +
                "        <Rate_Cd type=\"string\">  0</Rate_Cd>\n" +
                "        <Department_Code type=\"string\">10</Department_Code>\n" +
                "        <Department_Name type=\"string\">外科</Department_Name>\n" +
                "        <Cd_Information type=\"record\">\n" +
                "          <Ac_Money type=\"string\">      2000</Ac_Money>\n" +
                "          <Ic_Money type=\"string\">      2000</Ic_Money>\n" +
                "          <Ai_Money type=\"string\">         0</Ai_Money>\n" +
                "          <Oe_Money type=\"string\">      2000</Oe_Money>\n" +
                "          <Ml_Smoney type=\"string\">         0</Ml_Smoney>\n" +
                "        </Cd_Information>\n" +
                "        <Ac_Point_Information type=\"record\">\n" +
                "          <Ac_Ttl_Point type=\"string\">      4032</Ac_Ttl_Point>\n" +
                "          <Ac_Point_Detail type=\"array\">\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">A00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">初・再診料</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">B00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">医学管理等</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">C00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">在宅療養</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">F00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">投薬</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">G00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">注射</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">J00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">処置</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">K00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">手術</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">L00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">麻酔</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">D00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">検査</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">E00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">画像診断</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">H00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">リハビリ</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">I00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">精神科専門</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">M00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">放射線治療</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">N00</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">病理診断</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">         0</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "            <Ac_Point_Detail_child type=\"record\">\n" +
                "              <AC_Point_Code type=\"string\">A10</AC_Point_Code>\n" +
                "              <AC_Point_Name type=\"string\">入院料</AC_Point_Name>\n" +
                "              <AC_Point type=\"string\">      4032</AC_Point>\n" +
                "            </Ac_Point_Detail_child>\n" +
                "          </Ac_Point_Detail>\n" +
                "        </Ac_Point_Information>\n" +
                "        <Ml_Cost type=\"string\">         0</Ml_Cost>\n" +
                "      </Income_Information_child>\n" +
                "    </Income_Information>\n" +


                "    <Insurance_Information type=\"array\">\n" +
                "      <Insurance_Information_child type=\"record\">\n" +
                "        <Insurance_Combination_Number type=\"string\">0002</Insurance_Combination_Number>\n" +
                "        <InsuranceProvider_Class type=\"string\">060</InsuranceProvider_Class>\n" +
                "        <InsuranceProvider_Number type=\"string\">138057</InsuranceProvider_Number>\n" +
                "        <InsuranceProvider_WholeName type=\"string\">国保</InsuranceProvider_WholeName>\n" +
                "        <HealthInsuredPerson_Symbol type=\"string\">１２３</HealthInsuredPerson_Symbol>\n" +
                "        <HealthInsuredPerson_Number type=\"string\">４５６</HealthInsuredPerson_Number>\n" +
                "        <PublicInsurance_Information type=\"array\">\n" +
                "          <PublicInsurance_Information_child type=\"record\">\n" +
                "            <PublicInsurance_Class type=\"string\">019</PublicInsurance_Class>\n" +
                "            <PublicInsurance_Name type=\"string\">原爆一般</PublicInsurance_Name>\n" +
                "            <PublicInsurer_Number type=\"string\">19113760</PublicInsurer_Number>\n" +
                "            <PublicInsuredPerson_Number type=\"string\">1234567</PublicInsuredPerson_Number>\n" +
                "          </PublicInsurance_Information_child>\n" +
                "        </PublicInsurance_Information>\n" +
                "      </Insurance_Information_child>\n" +
                "    </Insurance_Information>\n" +
                "  </private_objects>\n" +
                "</xmlio2>";

        JacksonXmlModule module = new JacksonXmlModule();
        module.setDefaultUseWrapper(true);
        XmlMapper xmlMapper = new XmlMapper(module);
        ShunouWrapper responseWrapper = xmlMapper.readValue(data, ShunouWrapper.class);

        System.out.println(responseWrapper);
    }

    @Test
    public void testXmlDeserialize() throws Exception {
        JacksonXmlModule module = new JacksonXmlModule();
        module.setDefaultUseWrapper(true);
        XmlMapper xmlMapper = new XmlMapper(module);
        ShunouRequest request = xmlMapper.readValue("<private_objects type=\"record\"><Patient_ID type=\"string\">12</Patient_ID><Perform_Month type=\"string\">2013-10</Perform_Month></private_objects>", ShunouRequest.class);

        SimpleModule m = new SimpleModule("module", new Version(1, 0, 0, null, null, null));
        m.addSerializer(ShunouRequest.class, new JsonSerializer<ShunouRequest>() {
            @Override
            public void serialize(ShunouRequest shunouRequest, JsonGenerator jgen, SerializerProvider serializerProvider) throws IOException, JsonProcessingException {
                ToXmlGenerator xmlGenerator = (ToXmlGenerator) jgen;
                xmlGenerator.writeStartObject();
                xmlGenerator.setNextIsAttribute(true);
                xmlGenerator.setNextIsUnwrapped(true);
                xmlGenerator.writeStringField("type", "string");
                xmlGenerator.setNextIsAttribute(false);
                //xmlGenerator.
                xmlGenerator.writeObjectField("extra_field", "whatever_value");
                xmlGenerator.writeEndObject();
            }
        });
        xmlMapper.registerModule(m);
        String xml = xmlMapper.writeValueAsString(request);

        System.out.println(xml);
    }

}
