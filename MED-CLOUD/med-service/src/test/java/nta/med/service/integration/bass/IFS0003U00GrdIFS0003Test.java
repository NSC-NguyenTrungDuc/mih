package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class IFS0003U00GrdIFS0003Test extends MessageRequestTest {


    @Test
    public void test() throws InterruptedException {
        BassServiceProto.IFS0003U00GrdIFS0003Request request = BassServiceProto.IFS0003U00GrdIFS0003Request
                .newBuilder().setMapGubun("IF_ORCA_GWA").setMapGubunYmd("2016/01/07").setCode("%").setAcctType("00").build();

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}