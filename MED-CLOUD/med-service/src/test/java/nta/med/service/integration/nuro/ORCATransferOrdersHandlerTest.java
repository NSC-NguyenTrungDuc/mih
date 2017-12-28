package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.integration.MessageRequestTest;
import nta.med.service.orca.proto.OrcaServiceProto;

public class ORCATransferOrdersHandlerTest extends MessageRequestTest{

	@Test
	public void testORCATransferOrdersHandler() throws InterruptedException{
		OrcaServiceProto.ORCATransferOrdersRequest request = OrcaServiceProto.ORCATransferOrdersRequest.newBuilder()
				.setHospCode("K01")
				.setBunho("000001648")
				.setPkout1001("3600")
				.build();
		
		sentRequestToMedApp(request, OrcaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
