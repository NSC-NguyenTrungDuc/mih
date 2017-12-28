package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class BAS0111U00VzvJohapTest extends MessageRequestTest  {

    @Test
    public void testBAS0111U00VzvJohap() throws InterruptedException {

        BassServiceProto.BAS0111U00VzvJohapRequest request = BassServiceProto.BAS0111U00VzvJohapRequest
                .newBuilder().setFJohap("15050198").setFStartDate("2000/1/1")
                .build();
        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
