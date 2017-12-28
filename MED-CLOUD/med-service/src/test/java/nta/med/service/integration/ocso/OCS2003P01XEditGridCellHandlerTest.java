package nta.med.service.integration.ocso;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003P01XEditGridCellHandlerTest  extends MessageRequestTest {
	 	@Test
	    public void testOCS2003P01XEditGridCell()  throws InterruptedException {

	        OcsiServiceProto.OCS2003P01XEditGridCellRequest request = OcsiServiceProto.OCS2003P01XEditGridCellRequest.newBuilder()
	                      .build();
	        sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().
	                getOptions().getExtension(Rpc.service));
	    }
}
