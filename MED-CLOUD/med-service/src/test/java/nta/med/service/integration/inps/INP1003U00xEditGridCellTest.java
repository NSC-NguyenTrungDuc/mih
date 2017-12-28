package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author vnc.tuyen
 */
public class INP1003U00xEditGridCellTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1003U00xEditGridCellRequest request = InpsServiceProto.INP1003U00xEditGridCellRequest.newBuilder()
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
