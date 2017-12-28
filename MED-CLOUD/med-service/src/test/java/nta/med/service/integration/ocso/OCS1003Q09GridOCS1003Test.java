package nta.med.service.integration.ocso;

import com.google.protobuf.Message;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class OCS1003Q09GridOCS1003Test extends MessageRequestTest {

    @Test
    public void testOCS1003Q09GridOCS1003() throws InterruptedException {

        OcsoServiceProto.OCS1003Q09GridOCS1003Request request = OcsoServiceProto.OCS1003Q09GridOCS1003Request.newBuilder().
                setBunho("000001061").
                setDoctor("K01OCS").
                setGenericYn("N")
                .setGwa("01")
                .setInputGubun("D0")
                .setInputTab("%")
                .setIoGubun("O")
                .setJubsuNo("1")
                .setKijun("O")
                .setNaewonDate("2015/09/21")
                .setNaewonType("O")
                .setPkOrder("")
                .setTelYn("%")
                .build();
        sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
