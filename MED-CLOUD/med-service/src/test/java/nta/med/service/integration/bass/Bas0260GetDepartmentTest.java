package nta.med.service.integration.bass;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class Bas0260GetDepartmentTest extends MessageRequestTest{

    @Test
    public void testBas0260GetDepartment() throws InterruptedException {

        BassServiceProto.Bas0260GetDepartmentRequest request = BassServiceProto.Bas0260GetDepartmentRequest.newBuilder()
        		.setHospCode("K01")
        		.setLocale("")
        		.build();

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
