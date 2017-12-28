package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class BAS0310P01ProcessTest extends MessageRequestTest{

    @Test
    public void testBAS0310P01Process() throws InterruptedException {
        BassServiceProto.BAS0310P01ProcessRequest request =  BassServiceProto.
                BAS0310P01ProcessRequest.newBuilder().setProcGubun("DRG").
                setUserId("1111aa").
                setUpdateProcName("PR_ADM_UPDATE_MASTER_COM").build();

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));

        BassServiceProto.BAS0310P01ProcessRequest request2 =  BassServiceProto.
                BAS0310P01ProcessRequest.newBuilder().setProcGubun("JIN").
                setUserId("SAM001").
                setUpdateProcName("PR_ADM_UPDATE_MASTER_COM").build();

        sentRequestToMedApp(request2, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));



        BassServiceProto.BAS0310P01ProcessRequest request3 =  BassServiceProto.
                BAS0310P01ProcessRequest.newBuilder().setProcGubun("NTA").
                setUserId("SAM001").
                setUpdateProcName("PR_ADM_UPDATE_MASTER_SUSIK").build();

        sentRequestToMedApp(request3, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }

}
