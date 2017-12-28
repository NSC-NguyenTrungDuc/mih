package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class BAS0111U00VzvZipCodeTest extends MessageRequestTest  {

    @Test
    public void testBAS0111U00VzvZipCode() throws InterruptedException {

        BassServiceProto.BAS0111U00VzvZipCodeRequest request = BassServiceProto.BAS0111U00VzvZipCodeRequest
                .newBuilder().setFZip1("").setFZip2("")
                .build();
        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
