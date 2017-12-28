package nta.med.service.integration.emr;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class EMRGetLatestWarningStatusTest extends MessageRequestTest {

    @Test
    public void testEMRGetLatestWarningStatus() throws InterruptedException {
        EmrServiceProto.EMRGetLatestWarningStatusRequest request = EmrServiceProto.EMRGetLatestWarningStatusRequest
                .newBuilder().setBunho("000001324")
                .build();

        sentRequestToMedApp(request, EmrServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
