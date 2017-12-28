package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author vnc.tuyen
 */
public class INP1003U00MakeHodongComboTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		InpsServiceProto.INP1003U00MakeHodongComboRequest request = InpsServiceProto.INP1003U00MakeHodongComboRequest.newBuilder()
				.setHospCode("323")
				.setReserDate("2015/01/01")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
