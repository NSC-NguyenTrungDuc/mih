package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author vnc.tuyen
 */
public class INP1003U00grdInpReserTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		
		// set % for hoDong
		InpsServiceProto.INP1003U00grdInpReserRequest request = InpsServiceProto.INP1003U00grdInpReserRequest.newBuilder()
				.setHospCode("323")
				.setReserDate("2015/01/01")
				.setHoDong("%")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
